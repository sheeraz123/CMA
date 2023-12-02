import { Component } from '@angular/core';
import { MemberView } from './models/member-view.model';
import { MemberService } from './services/member.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Contacts App';
 
}

