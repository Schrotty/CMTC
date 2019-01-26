@.str = private unnamed_addr constant [5 x i8] c"%d\0D\0A\00"

define i32 @main(i32, i8**)
{
	%3 = alloca i32
	%4 = alloca i32
	%5 = alloca i8**
	store i8** %1, i8*** %5
	%6 = alloca i32
	%7 = load i8**, i8*** %5
	%8 = getelementptr inbounds i8*, i8** %7, i64 1
	%9 = load i8*, i8** %8
	%10 = call i32 @atoi(i8* %9)
	store i32 %10, i32* %6
	%11 = load i32, i32* %6
	store i32 %11, i32* %3
	%12 = alloca i8**
	store i8** %1, i8*** %12
	%13 = alloca i32
	%14 = load i8**, i8*** %12
	%15 = getelementptr inbounds i8*, i8** %14, i64 2
	%16 = load i8*, i8** %15
	%17 = call i32 @atoi(i8* %16)
	store i32 %17, i32* %13
	%18 = load i32, i32* %13
	store i32 %18, i32* %4
	%19 = load i32, i32* %3
	%20 = load i32, i32* %4
	%21 = add i32 %19, %20

	ret i32 %21
}


declare i32 @printf(i8*, ...)

; Function Attrs: nounwind readonly
declare i32 @atoi(i8*)