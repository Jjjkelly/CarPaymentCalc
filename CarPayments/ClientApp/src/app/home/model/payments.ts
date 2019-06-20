export class PaymentsModel {
  constructor(
    public BorrowAmount: number,
    public DepositAmount: number,
    public DeliveryDate: Date,
    public YearsOfAgreement: number
  ) { }
}
