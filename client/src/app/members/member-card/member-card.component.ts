import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
//we want to recieve from our paren component input with current member
@Input() member:Member;//getting input from member-list.component.ts


  constructor() { }

  ngOnInit(): void {
  }

}
