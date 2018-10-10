import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class NotifierService {
    constructor(private toastr: ToastrService) { }

    showSuccess(message: string, title: string) {
        this.toastr.success(message, title);
    }

    error(message: string, title: string) {
        this.toastr.error(message, title);
    }
}
