import { Injectable } from '@angular/core';
import { HttpClient, HttpBackend } from '@angular/common/http'
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MemberView } from '../models/member-view.model';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  private httpClient: HttpClient | null = null;
  urlPrefix: string = "http://localhost:5179/api/v1/Member";

  constructor(private httpBackend: HttpBackend) { }

  public AddMember(memberView: MemberView): Observable<any> {
    this.httpClient = new HttpClient(this.httpBackend);
    return this.httpClient.post<any>(this.urlPrefix, memberView, { responseType: "json", observe: "response" })
      .pipe(map(response => {
        if (response) {

          return true;
        }
        else
          return false;
      }));
  }
  getAllMembers(): Observable<MemberView[]> {
    this.httpClient = new HttpClient(this.httpBackend);
    return this.httpClient.get<MemberView[]>(this.urlPrefix, { responseType: "json" })
      .pipe(map((data: MemberView[]) => {
        return data;
      }))
  }
  public deleteMember(id: number): Observable<any> {
    this.httpClient = new HttpClient(this.httpBackend);
    return this.httpClient.delete<any>(this.urlPrefix + "?id=" + id, { responseType: "json", observe: "response" })
      .pipe(map(response => {
        return response;
      }));
  }
  public updateMember(memberView: MemberView): Observable<any> {
    this.httpClient = new HttpClient(this.httpBackend);
    return this.httpClient.put<any>(this.urlPrefix, memberView, { responseType: "json", observe: "response" })
      .pipe(map(response => {
        if (response) {

          return true;
        }
        else
          return false;
      }));
  }
  getMemberById(id:number): Observable<any>{
    this.httpClient=new  HttpClient(this.httpBackend);
    return this.httpClient.get<any>(this.urlPrefix + "/" + id, { responseType: "json", observe: "response" })
    .pipe(map(response => {
      return response;
    }));
  }

}
