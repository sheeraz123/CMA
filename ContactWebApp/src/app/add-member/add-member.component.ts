import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { MemberView } from '../models/member-view.model';
import { MemberService } from '../services/member.service';
import { ActivatedRoute,  Router } from '@angular/router';

@Component({
  selector: 'app-add-member',
  templateUrl: './add-member.component.html',
  styleUrls: ['./add-member.component.scss']
})
export class AddMemberComponent implements OnInit {
  @Output() displayMessage = new EventEmitter();
  @Input() editId = Number;
  @Output() backClick = new EventEmitter();
  addMemberForm: FormGroup | any = null;
  memberInfo: MemberView | any;
  id: number | any;
  headerMsg: string | any;

  constructor(private formbuilder: FormBuilder, private memberService: MemberService,
    private router: Router, private activateRoute: ActivatedRoute) { }

  ngOnInit() {

    this.id = this.editId;
    console.log(this.id);
    if (this.id) {
      this.headerMsg = "Update Member";
      this.getMemberInfoById(this.id);

    }
    else {
      this.headerMsg = "add Member"
    }
    this.addMemberForm = new FormGroup({
      id: new FormControl(0),
      firstName: new FormControl(null, [Validators.required, Validators.minLength(1)]),
      lastName: new FormControl(null, [Validators.required, Validators.minLength(1)]),
      email: new FormControl(null, [Validators.required, Validators.email])
    });
  }

  getMemberInfoById(id: number) {
    this.memberService.getMemberById(id).subscribe(
      {
        next: (response) => {
          debugger;
          this.addMemberForm.patchValue({
            firstName: response.body.firstName, lastName:response.body.lastName,
            email: response.body.email, id: response.body.id
          });
        },
        error: (e) => console.error(e),
        complete: () => {
          console.log('completed');
        }
      }
    );
  }

  UpdateMember(memberModel: MemberView) {
    this.memberService.updateMember(memberModel).subscribe({
      next: (response) => {
        this.addMemberForm.reset();
        this.displayMessage.emit('Record update successfully.')
        //this.router.navigate(["ViewMember"]);
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete')
    })
  }

  AddMember(memberModel: MemberView) {
    this.memberService.AddMember(memberModel).subscribe({
      next: (response) => {
        this.addMemberForm.reset();
        this.displayMessage.emit('Record added successfully.')
        this.router.navigate(["ViewMember"]);
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete')
    })
  }
  onBackClick() {
    this.backClick.emit(false);
  }
  onSubmitClick() {
    if (this.addMemberForm.valid) {
      var memberModel = this.addMemberForm.value as MemberView


      if (memberModel.id > 0) {
        this.UpdateMember(memberModel);
      }
      else {
        this.AddMember(memberModel);
      }
    }
  }
}
