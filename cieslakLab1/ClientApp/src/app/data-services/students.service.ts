import { Injectable } from '@angular/core';
import { Student } from '../model/student';

@Injectable()
export class StudentsService {

  collection: Student[] = [];
  nextId: number = 1;
  constructor() { }

  getAll() {
    return this.collection;
  }

  findbyId(id: number) {
    return this.collection.find(s => s.Id == id);
  }

  insert(student: Student) {
    student.Id = this.nextId++;
    this.collection.push(student);
  }

  update(student: Student) {
    let stud = this.findbyId(student.Id);
    Object.assign(stud, student);
  }

  delete(student: Student) {

  }
}
