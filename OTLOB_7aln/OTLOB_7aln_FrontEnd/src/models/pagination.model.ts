export interface Pagination<T> {
    data: T[];
    pageIndex: number;
    pageSize: number;
    count: number;
  }