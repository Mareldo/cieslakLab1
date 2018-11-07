import { Component } from "@angular/core";

@Component({
  selector: "first",
  templateUrl: "first.component.html"
})

export class FirstComponent {
  private kolekcja = [
    { nazwa: "Ala", wartosc: 12 },
    { nazwa: "Ola", wartosc: 23 },
    { nazwa: "Tomek", wartosc: 34 }
  ];
}
