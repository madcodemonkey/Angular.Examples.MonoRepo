import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { take } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ToolService {
  baseUrl = '/api';

  constructor(private http: HttpClient) { }

  /**
   * This shows an example of pulling the file name out of the header so that the user can specify it.
   * @param numberToCreate  Number of items to create in the CSV file inside the zip file you will download.
   */
  downloadToolReportUseServerFileName(numberToCreate: number) {

    this.getToolReport(numberToCreate)
         .pipe(take(1))
        .subscribe(resp => {

          // Note that the server has to allow access to the content-disposition headers (see ToolReportController.cs where it exposes the headers.)
          const contentDisposition = resp.headers.get('content-disposition');
          const filename = contentDisposition !== null ? contentDisposition.split(';')[1].split('filename')[1].split('=')[1].trim() : 'unknown.zip';
          console.log(filename);

          if (resp.body !== null) this.downloadFile(resp.body, filename)
        });
  }

  /**
   * This shows an example of pulling the file name out of the header so that the user can specify it.
   * @param numberToCreate  Number of items to create in the CSV file inside the zip file you will download.
   */
   downloadToolReportUseClientFileName(numberToCreate: number, filename: string) {

    this.getToolReport(numberToCreate)
         .pipe(take(1))
        .subscribe(resp => {
          if (resp.body !== null) this.downloadFile(resp.body, filename)
        });
  }

  /**
   * This allows the client to handle the blob and have more control.
   * @param numberToCreate  Number of items to create in the CSV file inside the zip file you will download.
   */
  getToolReport(numberToCreate: number): Observable<HttpResponse<Blob>> {
    return this.http.get(`${this.baseUrl}/ToolReport/${numberToCreate}`, {observe: 'response', responseType: 'blob' });
  }

  /**
   * Takes the blob and a file name and downloads the file to the user's hard drive.
   * @param data The blob data
   * @param filename The file name.
   */
  downloadFile(data: Blob, filename: string) {
    const blob = new Blob([data], { type: 'application/zip' });
    const url= window.URL.createObjectURL(blob);
    const anchor = document.createElement("a");
    anchor.download = filename;
    anchor.href = url;
    anchor.click();
    //window.open(url);
  }
}
