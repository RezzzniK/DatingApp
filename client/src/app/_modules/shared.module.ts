import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import {TabsModule} from 'ngx-bootstrap/tabs';//importing ngx-bootstrap tabs module
import { NgxGalleryModule } from '@kolkov/ngx-gallery';//adding lib for photo gallery

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass:'toast-bottom-left'//we adding our notifications to thr 
                                      //bottom right scree
    }),
    TabsModule.forRoot(),//adding ngx-bootstrap tabs module to our root
    NgxGalleryModule//adding photo gallery module for import
  ],
  exports:[
    BsDropdownModule,
    ToastrModule,
    TabsModule, //adding our tabs module to be able to export
    NgxGalleryModule//adding photo gallery module for export

  ]
})
export class SharedModule { }
