import { NgModule } from '@angular/core';
import { OrderrByPipe } from './../Pipes/order.pipe';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [CommonModule],
    declarations: [OrderrByPipe],
    exports: [OrderrByPipe],
})
export class OrderFilterModule {
    
}