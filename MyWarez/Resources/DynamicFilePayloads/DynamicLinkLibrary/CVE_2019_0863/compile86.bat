call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\VC\Auxiliary\Build\VCVARSALL.bat" x86 -vcvars_ver=14.16
devenv CVE_2019_0863.sln /Rebuild "Release|x86"
copy Release\CVE_2019_0863.dll .