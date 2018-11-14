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

  private trybEdycji = false;

  private obiekt = { nazwa: "", wartosc: 0 };

  dodajWiersz() {
    this.kolekcja.push(Object.assign({}, this.obiekt));
  }

  edytujWiersz(o) {
    this.obiekt = o;
    this.trybEdycji = true;
  }

  usunWiersz(o) {
    this.kolekcja.pop();
  }

  zapiszWiersz() {
    this.obiekt = { nazwa: "", wartosc: 0 };
    this.trybEdycji = false;
  }
}
