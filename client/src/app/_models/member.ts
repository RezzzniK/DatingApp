import { Photo } from "./photo";

export interface Member{//export stands for export to other classes
    id:number;
    username:string;
    photoUrl:string;
    age:number;
    knownAs:string;
    created:Date;
    lastActive:Date;
    gender:string;
    introduction:string;
    lookingFor:string;
    interests:string;
    city:string;
    country:string;
    photos:Photo[];//going to declare this type

}


