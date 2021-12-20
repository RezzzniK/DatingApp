import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';
import { MembersService } from '_services/members.service';

@Component({
  selector: 'app-members-list',
  templateUrl: './members-list.component.html',
  styleUrls: ['./members-list.component.css']
})
export class MembersListComponent implements OnInit {
  /*creating object to store list of members */
  members:Member[];
/*FIRS WE WANT TO INJECT OUR MEMBERSSERVICE INTO COMPONENT */
  constructor(private memberService:MembersService) { }

  ngOnInit(): void {
    //also we wont on init to load our members
    this.loadMembers();
  }


  /*creating method to load members */
  loadMembers(){
    this.memberService.getMembers()./*we need to subscribe because we getting observables*/
                                    subscribe(/*passing our members array that we created in this file*/
                                      members=>{
                                        this.members=members;//from service
                                      })
  }

}
