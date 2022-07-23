import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { take } from 'rxjs/operators';
import { ToolService } from '../../_services/tool.service';

@Component({
  selector: 'app-download-file-example',
  templateUrl: './download-file-example.component.html',
  styleUrls: ['./download-file-example.component.scss'],
})
export class DownloadFileExampleComponent implements OnInit {
  constructor(
    private toolService: ToolService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {}

  downloadIt1(): void {
    this.toolService.downloadToolReportUseServerFileName(1000);
  }

  downloadIt2(): void {
    this.toolService
      .getToolReport(1000)
      .pipe(take(1))
      .subscribe({
        next: (resp) => {
          if (resp.body) {
            this.toolService.downloadFile(resp.body, 'MoreControlFile.zip');
            this.snackBar.open('File downloaded.', '', {
              duration: 3000
            });

          } else {
            this.snackBar.open('No blob data returned for the file (see console output)', '', {
              duration: 3000
            });
            console.log(resp);
          }
        },
        error: (e) => {
          this.snackBar.open('Error (see console output)', '', {
            duration: 3000
          });
          console.log(e);
        },
      });
  }
}
