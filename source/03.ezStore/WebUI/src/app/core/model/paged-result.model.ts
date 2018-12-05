export class PagedResult<T> {
    CurrentPage: number;
    PageCount: number;
    PageSize: number;
    RowCount: number;
    Results: T[];
}
