import { Component } from '@angular/core';
import { PaymentsModel } from './model/payments';
import { RepaymentsInterface } from './interface/repayments'
import { PaymentService } from '../service/payment.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(
    private paymentService: PaymentService
  ) { }

  model = new PaymentsModel(null, null, null, null);
  resultList: RepaymentsInterface[];
  IsGreaterThan15PerCent: boolean = true;
  submitted: boolean = false;

  SetDefaultDeposit(inputValue: number) {

    this.model.DepositAmount = Number(Math.round(((inputValue/ 100) * 15)*100)/100);
    this.model.BorrowAmount = Number(Math.round(this.model.BorrowAmount*100 )/100);

  }

  CheckIfDepositIsEnough(inputValue: number)
  {
    this.IsGreaterThan15PerCent = (Number(Math.round(((this.model.BorrowAmount / 100) * 15) * 100) / 100) <= inputValue);
  }

  onSubmit() {
    this.submitted = true;
    this.paymentService.postDetailsForPlan(this.model).subscribe(data => {
      this.resultList = data
    });
  }

}
