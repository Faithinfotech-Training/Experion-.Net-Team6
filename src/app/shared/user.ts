import { Role } from "./role";

export class User {
    UserId:number;
    UserName:String;
    Password:string;
    RoleId:number;

    Role:Role
    IsActive:boolean;
}
