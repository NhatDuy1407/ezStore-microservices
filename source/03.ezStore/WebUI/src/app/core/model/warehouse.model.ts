import { Entity } from './entity.model';

export class WareHouseModel extends Entity<string> {
    name: string;
    address: string;
    city: string;
    countryId: number;
    countryName: string;
    provinceId: number;
    provinceName: string;
    phoneNumber: string;
    postalCode: string;
}
