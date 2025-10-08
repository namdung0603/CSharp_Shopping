------ Sử dụng PATCH trong .Net -------

1\. Tải Microsoft.AspNetCore.Mvc.NewtonsoftJson

2\. \[FromBody] JsonPatchDocument<UserRequestUpdate> patchDoc thay vì dùng \[FromBody] UserRequestUpdate userRequestUpdate

&nbsp;	- pathDoc này sẽ chứa các phương thức như replace, add, remove,....

&nbsp;	- pathDoc chỉ là hướng dẫn sửa, chưa có dữ liệu để sửa.

3\. Luồng sửa của nó như sau:

&nbsp;	- Bạn cho vào postman theo form dưới:

&nbsp;		**\[{ "op": "replace", "path": "/fullname", "value": "Lê Nhân Updated" }]**

&nbsp;	- Sau khi ấn gửi, luồng chạy của nó như sau:

&nbsp;		1. Lấy user trong database

&nbsp;		2. Sau đó tạo một bản trung gian UserRequestUpdate (tên là userToPatch). Cơ chế là lấy dữ liệu từ entity user rồi map sang 

&nbsp;			userToPatch những trường mà nó có.

&nbsp;		3. Áp dụng PATCH lên bản trung gian:

&nbsp;			**patchDoc.ApplyTo(userToPatch, ModelState);**

			patchDoc chạy qua từng operation. /fullname -> tìm thuộc tính FullName của userToPatch sau đó đổi giá trị ban đầu 

&nbsp;			bằng giá trị trong value.

&nbsp;		4. Map ngược về entity thật

&nbsp;		5. Cuối cùng cập nhật và save



