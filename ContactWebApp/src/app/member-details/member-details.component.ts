import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MemberView } from '../models/member-view.model';
import { MemberService } from '../services/member.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-member-details',
  templateUrl: './member-details.component.html',
  styleUrls: ['./member-details.component.scss']
})

export class MemberDetailsComponent {
  memberInfo: MemberView[] = [];
  editId: any;
  msg: string | any;
  edited: boolean = false;

  constructor(private memberService: MemberService, private router: Router) { }

  ngOnInit() {
    this.getMemberInfo();
  }

  onEditClick(id: Number) {
    this.editId = id;
    this.showAddEditMember();
  }

  showAddEditMember() {
    this.edited = true;
  }
  showMessage(message: string) {
    this.msg = message;
    this.edited = false;
    this.getMemberInfo();
    alert(this.msg);
  }
  backClick(showHide: boolean) {
    this.edited = showHide;
  }

  getMemberInfo() {
    this.memberService.getAllMembers().subscribe(
      (response: MemberView[]) => {
        this.memberInfo = response;
      });
  }

  onDeleteClick(event: any, id: number) {
    if (confirm("Are you sure to you want to delete?")) {
      console.log(id);
      this.memberService.deleteMember(id).subscribe({
        next: (response) => {
          if (response) {
            console.log(response.body);
            alert("Data seleted successfully.")
          }
        },
        error: (e) => {
          console.error(e);
        },
        complete: () => {
          console.info('complete');
          this.getMemberInfo();
          this.router.navigate(['ViewMember']);
        }
      });
    }
  }
}
