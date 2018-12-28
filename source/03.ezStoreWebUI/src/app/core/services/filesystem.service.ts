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
        this.getFile(`file\\${id}`).subscribe(resp => {
            let filename = '';
            const disposition = resp.headers.get('Content-Disposition');
            if (disposition && disposition.indexOf('attachment') !== -1) {
                const filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
                const matches = filenameRegex.exec(disposition);
                if (matches != null && matches[1]) {
                    filename = matches[1].replace(/['"]/g, '');
                }
            }
            this.downloadDocument(resp.body, filename);
        });
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
