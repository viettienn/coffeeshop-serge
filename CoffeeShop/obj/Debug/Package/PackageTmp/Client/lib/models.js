function Beverage() {
    this.Id = 0;
    this.BeverageType;
    this.Name;
    this.BeveragePrices = [];
}

function BeveragePrice() {
    this.Id = 0;
    this.BeverageId;
    this.BeverageSizeId;
    this.Price;
}

function BeverageSize() {
    this.Id = 0;
    this.BeverageId;
    this.SizeId;
}

function Order() {
    this.Id = 0;
    this.BeverageId;
    this.BeverageSizeId;
    this.BeveragePriceId;
    this.Canceled = false;
    this.CancelationReason = '';
}

function Size() {
    this.Id = 0;
    this.Name = "";
}