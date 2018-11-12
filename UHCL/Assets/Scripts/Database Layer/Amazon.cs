using System;
using UnityEngine;

public class amazon : MonoBehaviour
{
    private object client;

    // Use this for initialization
    void Start()
    {
        //string accessKey = "AKIAID34YIUFUW4PD5XQ";
        //string secretKey = "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";

        //AmazonS3Config config = new AmazonS3Config();
        //config.ServiceURL = "https://nasasuits.s3.us-east-2.amazonaws.com/disablingalarmprocedure.json?X-Amz-Expires=3597&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAJDD2SLSSRJWQWBRA/20180417/us-east-2/s3/aws4_request&X-Amz-Date=20180417T193400Z&X-Amz-SignedHeaders=host&X-Amz-Signature=8b1732edc44eba22b33958753a23bead002a37bdfe1c7d51358ae7031c5e3b51";

        //AmazonS3Client s3Client = new AmazonS3Client(
        //        accessKey,
        //        secretKey,
        //        config
        //        );

        //GetObjectRequest request = new GetObjectRequest();
        //request.BucketName = "nasasuits";
        //request.Key = "disablingalarmprocedure.json";
        //GetObjectResponse response = client.GetObject(request);
        //response.WriteResponseStreamToFile("C:\Users\Bhaavan Bruhant\Desktop\TASKS");

        //ListBucketsResponse response = client.ListBuckets();
        //foreach (S3Bucket b in response.Buckets)
        //{
        //    System.Console.WriteLine("{0}\t{1}", b.BucketName, b.CreationDate);
        //}
        //ListObjectsRequest request = new ListObjectsRequest();
        //request.BucketName = "my-new-bucket";
        //ListObjectsResponse response = client.ListObjects(request);
        //foreach (S3Object o in response.S3Objects)
        //{
        //    Console.WriteLine("{0}\t{1}\t{2}", o.Key, o.Size, o.LastModified);
        //}



    }

    // Update is called once per frame
    void Update()
    {

    }
}

