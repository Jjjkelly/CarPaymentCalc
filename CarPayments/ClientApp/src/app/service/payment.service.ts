import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { RepaymentsInterface } from '../home/interface/repayments';
import { PaymentsModel } from '../home/model/payments';
import { catchError, tap } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http: HttpClient) { }

  errorMessage: string = "";
  repayments: RepaymentsInterface;
  Headers = new HttpHeaders({
    'Content-Type': 'application/json',
  });

  postDetailsForPlan(paymentsModel: PaymentsModel): Observable<RepaymentsInterface[]> {
    const apiPath: string ="http://localhost:52797/api/CarPayment";

    const postRequest = this.http.post<RepaymentsInterface[]>(apiPath, paymentsModel).pipe(
      tap(data => console.log("Print: ", data)),
      catchError(this.handleError)
    );

    return postRequest;
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage: string;

    if (err.error instanceof ErrorEvent) {
      errorMessage = 'An error occurred: ' + err.error.message;
    } else {
      errorMessage = 'Server returned code: ' + err.status + ', error message is: ' + err.message;
    }

    return throwError(errorMessage);
  }




}
