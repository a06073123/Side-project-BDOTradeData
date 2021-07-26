dotnet publish --configuration Release -o ../bdo3_publish --force --self-contained true -r win10-x86
cd ../bdo3_publish/ClientApp/dist/bdo
move * ..
cd ..
rmdir bdo