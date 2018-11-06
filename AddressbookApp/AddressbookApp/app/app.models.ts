
export class Country {
   public PKCountryId: number;
   public CountryName: string;
   public ZipCodeStart: number;
   public ZipCodeEnd: number;
   public IsActive: boolean;
}

export class State {
   public PKStateId: number;
   public FKCountryId: number;
   public StateName: string;
   public IsActive: boolean;
   public Country: Country;
}


export class Addressbook {
    public PKAddressId: number;
    public FKStateId: number;
    public FKUserId: number;
    public FirstName: string;
    public LastName: string;
    public EmailId: string;
    public PhoneNo: string;
    public Address1: string;
    public Address2: string;
    public Street: string;
    public City: string;
    public ZipCode: number;
    public IsActive: boolean;
    public State: State;
    public Userdetail: Userdetail;
}

export class Userdetail {
    constructor() { }
   public PKUserId: number;
   public UserName: string;
   public Password: string;
   public FirstName: string;
   public LastName: string;
   public EmailId: string;
   public PhoneNo: number;
   public IsActive: boolean;
}

export class LoginModel {
    public UserName: string;
    public Password: string;
    public RememberMe: boolean;
}

