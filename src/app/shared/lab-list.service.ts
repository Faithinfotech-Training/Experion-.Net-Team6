import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core'; 
import { environment } from 'src/environments/environment';
import { LabList } from './lab-list';

@Injectable({
  providedIn: 'root'
})
export class LabListService {


  labList:LabList[];

  constructor(private httpClient:HttpClient) { }

  //get all lab list
  getAllLabList(){
    return this.httpClient.get(environment.apiUrl+"/api/Labtest/labtech")
    .toPromise().then(
      Response=>this.labList=Response as LabList[]
    )
  }
  
  //get prescribed test by LogId
  getLabTest(LogId:number){
    return this.httpClient.get(environment.apiUrl+"/api/labtest/"+LogId);
  }
}
