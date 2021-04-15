Уточнение:
1. Ошибка, которую мы встретили в конце занятия была из-за использования IFormFile в отложеном сценарии. Ее можно решить переделав ImageProcessingChanel на использования массива байт.

Теория:
1. Про итерацию с AsyncEnumerable: https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8
2. Отличное интервью с разработчиком Channels: https://www.youtube.com/watch?v=gT06qvQLtJ0

Практика:
1. Переделайте ImageProcessingChanel на использования массива байт вместо IFormFile.
2. Зарегистрируйте IExampleRestClient как scoped, найдите способ использовать его в hosted сервисах при таком типе регистрации.
3. Воспользуйтесь SlidingExpiration при внесении данных в MemoryCache.
4. Сделайте сделайте методы созданных нами hosted services и image controller ассинхронными.
5. Попробуйте доставать элементы из FileProcessing не подному, а все которые на данный момент есть в очереди. Воспользуйтесь await foreach. Увеличьте интервал работы фоновой задачи по отправке изображений.
6. Вместо использования строки пути "wwwroot" в ExternalImageService воспользуйтесь стандартными средставми IWebHostEnvironment. 