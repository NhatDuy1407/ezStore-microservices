import { Component, OnInit } from '@angular/core';
import { FileSystemService } from '../../../core/services/filesystem.service';
import { NotifierService } from '../../../core/notifier/notifier.service';

@Component({
  templateUrl: 'product.component.html'
})
export class ProductComponent implements OnInit {
  fileList: FileList;

  constructor(private fileSystemService: FileSystemService, private notification: NotifierService) { }

  ngOnInit(): void {
  }

  drop(droppedFiles) {
    this.fileList = droppedFiles.srcElement.files;
  }

  save() {
    const formData = new FormData();
    for (let i = 0; i < this.fileList.length; i++) {
      const file = this.fileList[i];
      const fileName = file.name;
      formData.append(fileName, file, fileName);
    }

    this.fileSystemService.uploadFile(formData).subscribe(() => {
      this.notification.showSuccess('File was uploaded!', 'File Upload');
    });
  }

  download() {
    this.fileSystemService.downloadFile(`5c24a7e59adb9503264e61f2`);
  }
}
