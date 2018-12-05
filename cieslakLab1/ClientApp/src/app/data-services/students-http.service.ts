import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import "rxjs/add/operator/map";
import "rxjs/add/operator/do";
import { Student } from "../model/student";
import { Subject } from "rxjs/Subject";

@Injectable()
export class StudentsService {

  url: string = "api/students";
  onResult: Subject<Student> = new Subject<Student>();

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<StudentDTO[]>(this.url)
      .map((studentDtos) =>
        studentDtos.map(s => new Student(s.id, s.firstName, s.lastName, s.grant)));
  }

  findbyId(id) {
    
  }

  insert(student) {
    return this.http.post<StudentDTO>(this.url, student)
      .map((s) => new Student(s.id, s.firstName, s.lastName, s.grant))
      .do(s => this.onResult.next(s));
  }

  update(student) {

  }
}

interface StudentDTO {
  id: number;
  firstName: string;
  lastName: string;
  grant: number;
}
