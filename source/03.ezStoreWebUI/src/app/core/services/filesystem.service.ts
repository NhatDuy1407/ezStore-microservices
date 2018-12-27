import { Injectable } from '@angular/core';
import { HttpService } from '../http/http.service';
import { environment } from '../../../environments/environment';
import { NotifierService } from '../notifier/notifier.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as FileSaver from 'file-saver';

@Injectable()
export class FileSystemService extends HttpService {
    get api() {
        return environment.filesystemServiceUrl;
    }

    constructor(private notifierService: NotifierService, http: HttpClient) {
        super(http);
    }

    uploadFile(formData: FormData): Observable<any> {
        return this.put(`file`, formData);
    }

    downloadFile(id: string) {
        window.location.href = this.api + `/file/${id}`;
        return;
        // this.get(`file\\${id}`).subscribe(result => {
        //     this.downloadDocument(result, `filename`);
        // });
    }

    private downloadDocument(result: any, fileName: string, fileType: string = 'application/octet-stream') {
        if (result) {
            const blob = new Blob([result], { type: fileType });
            FileSaver.saveAs(blob, fileName);
        } else {
            this.notifierService.error('Can not download file', 'File download');
        }
    }
}
