﻿using FacesApiTest;
using Newtonsoft.Json;
using System.Net.Http.Headers;

var imagePath = @"oscars-2017.jpg";
var urlAddress = "http://localhost:5111/api/faces/ReadFaces/";
ImageUtility imgUtil = new ImageUtility();
var bytes = imgUtil.ConvertToBytes(imagePath);
List<byte[]> faceList = null;
var byteContent = new ByteArrayContent(bytes);
byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
using (var httpClient = new HttpClient())
{
    using (var response = await httpClient.PostAsync(urlAddress, byteContent))
    {
        string apiResponse = await response.Content.ReadAsStringAsync();
        //faceList = JsonConvert.DeserializeObject<List<byte[]>>(apiResponse);
    }
}
//if (faceList != null && faceList.Count > 0)
//{
//    for (int i = 0; i < faceList.Count; i++)
//    {
//        imgUtil.FromBytesToImage(faceList[i], "face" + i);

//    }
//}