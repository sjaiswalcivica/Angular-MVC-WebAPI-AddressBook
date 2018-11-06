import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'orderBy' })
export class OrderrByPipe implements PipeTransform {

    transform(records: Array<any>, args?: any): any {
        if (args.direction !== undefined) {
            return records.sort(function (a, b) {

                if ((args.property as string).includes(".")) {
                    var obj = (args.property as string).split(".")[0];
                    var prop: any = ((args.property as string).split(".")[1]) as any;

                    if (a[obj][prop] < b[obj][prop]) {
                        return -1 * args.direction;
                    }
                    else if (a[obj][prop] > b[obj][prop]) {
                        return 1 * args.direction;
                    }
                    else {
                        return 0;
                    }
                }
                else {
                    if (a[args.property] < b[args.property]) {
                        return -1 * args.direction;
                    }
                    else if (a[args.property] > b[args.property]) {
                        return 1 * args.direction;
                    }
                    else {
                        return 0;
                    }
                }
            });
        }
        else {
            return records;
        }
    };
}