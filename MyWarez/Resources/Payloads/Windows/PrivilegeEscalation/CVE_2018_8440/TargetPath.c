#include <string>

wchar_t* GetTargetDirectoryW(void)
{
	wchar_t* target_dir = (wchar_t*)L"C:\\Windows\\System32\\";
	return target_dir;
}

wchar_t* GetTargetFilenameW(void)
{
	wchar_t* target_filename = (wchar_t*)L"license.rtf";
	return target_filename;
}

wchar_t* GetTargetPathW(void)
{
	wchar_t target_path[1000] = L"";
	wcscat(target_path, GetTargetDirectory());
	wcscat(target_path, GetTargetFilename());
	return target_path;
}