export class Entity<T> {
    id: T;
    createdDate: Date;
    createdBy: string;
    updatedDate: Date;
    updatedBy: string;
    deleted: boolean;
}
