# Proxy Storage API

A simple api implementation to upload any file to local storage.

## Usage

Sample Request to endpoint;
```shell
curl -X POST "https://localhost:5001/file/upload" -H  "accept: text/plain" -H  "Content-Type: multipart/form-data" -F "file=@218247.jpg;type=image/jpeg"
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)