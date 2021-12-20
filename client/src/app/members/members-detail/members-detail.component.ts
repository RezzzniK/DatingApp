import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { Member } from 'src/app/_models/member';
import { MembersService } from '_services/members.service';

@Component({
  selector: 'app-members-detail',
  templateUrl: './members-detail.component.html',
  styleUrls: ['./members-detail.component.css']
})
export class MembersDetailComponent implements OnInit {
  member:Member;//creating variable member of type Member

  /*declaring NgxGallery variables */
  galleryOptions:NgxGalleryOptions[];
  galleryImages:NgxGalleryImage[];

  constructor(/*injecting functionality from memberService*/
              private memberService:MembersService,
              /*bringing router service to be able 
              to route to the member details*/
              private router:ActivatedRoute) { }

  ngOnInit(): void {
    this.loadMember();
    /*providing gallery options */
    this.galleryOptions=[{
      width:'500px',
      height:'500px',
      imagePercent:100,
      thumbnailsColumns:4,//displaying 4 images beneath the image
      imageAnimation:NgxGalleryAnimation.Slide,
      preview:false

    }];
    
  }
  

  loadMember(){
    this.memberService.getMember(this.router.snapshot/*making virtual copy 
                                  of member structure*/.paramMap/**
                                  paramMap will give us accsess to structure 
                                  router properties */.get('username')).
                                  subscribe(member=>{
                                    this.member=member;
                                    this.galleryImages=this.getImages();
                                  });
    
  }
  /*creating method to get images from our member object */
  getImages():NgxGalleryImage[]{
    const ImageUrl=[];
    for(const photo of this.member.photos){
      //pushing our images into ngx gallery
      ImageUrl.push({
        small:photo?.url,
        medium:photo?.url,
        big:photo?.url

      })
    }
    return ImageUrl;//returning to the nGOnInint
  }
}
