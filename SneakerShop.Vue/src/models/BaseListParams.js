export default class BaseListParams {

    constructor(PageNumber, RowsCount, OrderBy, Filters)
    {
        this.PageNumber = PageNumber;
        this.RowsCount = RowsCount;
        this.OrderBy = OrderBy;
        this.Filters = Filters;
    }

    addFilter(filter) {
        // если фьльтра нет, то фильтр = переданному фильтру
        if (this.isEmpty(this.Filters)) {
            this.Filters = filter;
            return;
        }

        // если фильтр есть, то ищем фильтр без ссылки на следующий фильтр
        let curFilter = this.Filters;
        while (curFilter.NextFilter != undefined) {
            curFilter = curFilter.NextFilter;
        }

        curFilter.NextFilter = filter;
    }

    isEmpty(obj) {
        for (const prop in obj) {
            if (Object.hasOwn(obj, prop)) {
                return false;
            }
        }

        return true;
    }

}