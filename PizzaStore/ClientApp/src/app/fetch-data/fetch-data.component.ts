import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

  public pizzaList: Pizza[];
  public toppingList: Topping[];
  public crustList: Crust[];
  public pizzaCount = new Array();
  public selectedPizza: Pizza[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
    http.get<Pizza[]>(baseUrl + 'pizza').subscribe(result => {
      this.pizzaList = result;
      this.pizzaList.forEach(function (value) { value.count = 0, value.costWithTopping = value.cost, value.topping = new Array(), value.costWithCount = 0 });
    }, error => console.error(error));
    http.get<Topping[]>(baseUrl + 'topping').subscribe(result => {
      this.toppingList = result;
    }, error => console.error(error));
    http.get<Crust[]>(baseUrl + 'crust').subscribe(result => {
      this.crustList = result;
    }, error => console.error(error));
  }

  addItem(pizza: Pizza) {
    pizza.count = pizza.count + 1;
  }

  removeItem(pizza: Pizza) {
    if (pizza.count > 0) {
      pizza.count = pizza.count - 1;    
    }
  }

  addTopping(pizza: Pizza, topping: Topping) {
    if (pizza.topping.length == 0) {
      pizza.topping.push(topping);
    }
    else {
      let indexofTopping = -1;
      let count = -1;
      pizza.topping.forEach(function (value) {
        count = count + 1;
        if (value.name == topping.name) {
          indexofTopping = count;
        }
      });
      if (indexofTopping == -1) {
        pizza.topping.push(topping);
      }
      else {
        pizza.topping.splice(indexofTopping, 1);
      }
    }
    pizza.costWithTopping = pizza.cost;
    pizza.topping.forEach(function (value) {
      pizza.costWithTopping += value.cost;
    })
  }

  totalAmount() {
    var totalCost = 0;
    this.pizzaList.forEach(function (pizza) {
      if (pizza.count > 0) {
        totalCost += pizza.costWithTopping * pizza.count;
      }
    })
    return totalCost;
  }

  showTotal() {
    return (this.totalAmount() > 0);
  }

  //onCrustChange($event) {
  //  console.log(this.selectedCrust);
  //}
}

interface Pizza {
  name: string;
  imagePath: string;
  cost: number;
  costWithTopping: number;
  costWithCount: number;
  count: number;
  topping: Topping[];
}

interface Topping {
  name: string;
  cost: number;
}

interface Crust {
  name: string;
  cost: number;
}
