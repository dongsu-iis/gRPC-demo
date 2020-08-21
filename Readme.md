# gRPC demo

gRPCをお試しで作ってみました

- Server : `ASP.NET Core gRPC`
- Client : Angular

## Server

1. プロジェクト新規作成
    ```bash
    dotnet new grpc -o {project name}
    ```

## Client

1. プロジェクト新規作成
    ```bash
    ng new {project name}
    ```

2. 必要Libをインストール
    ```bash
    npm install ts-protoc-gen google-protobuf @types/google-protobuf @improbable-eng/grpc-web grpc protoc
    ```

3. 必要Libをインストール
    ```bash
    protoc --plugin=protoc-gen-ts="C:\Repository\gRPC-demo\grpcclient\node_modules\.bin\protoc-gen-ts.cmd" --js_out="import_style=commonjs,binary:src/app/generated" --ts_out="service=grpc-web:src/app/generated" src/app/protos/greet.proto
    ````
