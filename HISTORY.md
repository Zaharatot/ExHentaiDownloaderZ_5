# История версий
[1.0.0] Самая первая версия была написана ещё в далёком 2014 году (точная дата не сохранилась), после того, как я открыл 
для себя сайт g.e-hentai. Она была создана за ночь и работала максимально примитивно, но со своей задачей 
худо-бедно справлялась. Изначально, я просто напрямую грузил страницы через объект WebBrowser, и через его же
методы парсил html. Это было очень медленно, так что я похвастался ей перед другом, и лёг спать.

[2.0.0] Через некоторое время, я начал допиливать эту программу. Загрузка страниц теперь шла напрямую, через web-запросы а,
для парсинга страниц я использовал библиотеку HtmlAgilityPack. И это была уже по сути вторая версия программы, так 
как её код был переписан на 80%. Больше всего эти версии запомнилась тем, что тогда я начал фанатеть от "плоского стиля",
а их расцветка была вырвиглазной (а это уже моё врождённое чувство вкуса. Цвет Fuchsia на черном фоне, ммм...). 
Лучше всего, её расцветку характеризует фраза: "Твоя программа выжигает и мои глаза, и мой монитор!".

[3.0.0] Уже все те старые версии (включая самую первую) поддерживали такой функционал, как смена языка и сохранение списков загрузок.
Потихоньку функционал рос, добавлялись возможности проверки изображений, я понимал какая скорость парсинга не
приведёт к бану на ресурсе и т.п. И, на фоне всего этого, была предпринята попытка создать крутую, третью версию программы.
По задумке, она должна была быть не просто загрузчиком, но и эдакой оболочкой для сайта. тут нужно сделать отступление,
и рассказать о том, что все версии программы получают ссылки на страницы для загрузки изображений из буфера обмена. 
Т.е. пользователю нужно просто скопировать ссылку на корневую страницу интересующего его пака изображений (или манги),
и эта ссылка автоматически появится в загрузчике. Так вот, планы на третью версию были амбициозны - она должна была
исключить необходимость захода на сам сайт, вместо этого предлагая свою оболочку, дублирующую главную страницу сайта 
g.e-hentai. Но - не срослось, и третья версия так и осталась концептом.

[4.0.0] Прошло ещё немного времени, и я узнал о существовании такого сайта, как exhentai. немного пошарившись на нём, я понял,
что просто обязан добавить его поддержку в свою программу. Что я и реализовал. Там была даже подробная инструкция о том,
как получить доступ к этому сайту, и встроенный браузер, для автоматического вытягивания куков от g.e-hentai. Поскольку
изменений к этой версии накопилось уже достаточно, я принял решение, присвоить её четвёртый номер. Действительно - третья
версия, к тому моменту была успешно провалена, а изменений от изначальной версии текущей (второй) накопилось уже прилично.
Так что, данная версия получила гордый номер 4. Это было примерно в 2015 году.

Оглядываясь на те версии, я понимаю, что они легко могли занять первое место в номинации "Как НЕ НАДО писать код". 
Они были ужасны. Ни одного комментария, весь код был в классах форм, вместо потоков, я использовал таймеры...
На самом деле, когда я брал некоторые куски кода из тех версий, для текущей, мне было реально страшно на это смотреть.

С момента последнего обновления 4 версии, ко мне в голову регулрно приходили мысли о том, что всё это нужно 
переписать с чистого листа. И, такие попытки предпринимались мной с частотой примерно раз в год (я насчитал 4 проекта,
включая текущий). И все они разбивались об один факт - у меня не было мотивации что-либо переделывать. 4 версия
продолжала стабильно работать, а привычный до последнего пикселя интерфейс как будто говорил - "Зачем тебе всё это? 
У тебя же есть Я!". Годы шли, и любимая версия постепенно начинала работать нестабильно. Постепенно отваливалось то
одно то другое. И, каждый раз продираться сквозь дебри старого кода становилось крайне неуютно.

[5.0.0_test] Таким образом, осенью 2018 года появилась программка, с названием "ParsingTest". Это был тест задумок на то, как я сейчас
вижу парсер этих сайтов. Загрузка страниц и картинок осуществлялась как и во второй версии через web-запросы, но я 
полностью отказался от сторонних библиотек, заменив их на регулярные выражения. Немного протестировав всё это, я 
убедился в том, что ядро программы работает, его можно переносить в новую версию. Но, у меня была открыта куча вкладок
для загрузки, а 4 версия пребывала в крайне неработоспособном состоянии (к тому моменту, по какой-то причине, скорость
загрузки изображений упала ниже плинтуса, и я принял волевое решение не разбираться в чём там проблема). И я приляпал
к тестовой программе примитивный интерфейс (текстовое поле, куда втыкаются построчно ссылки, и кнопка запуска) и чуть-чуть
допилил основной рабочий класс.

Это было катастрофичной ошибкой - у меня появилась новая программа, которая хоть и криво, но выполняла свою задачу. 
К новой попытке создания загрузчика я приступил только через несколько месяцев. Логично посчитав, что раз готовое ядро уже
есть, то нужно начинать с интерфейса, заодно реализовав в виде отдельных библиотек некоторые свои старые задумки. Я 
провозился целый вечер, и дело снова встало на мёртвую точку (этому крайне способствовала и загруженность на работе).

[5.0.0] И вот сейчас, я снова взялся за этот проект. Допилил обе интерфейсных библиотеки и полностью перенёс ядро от "ParsingTest"
в новую, уже 5 версию загрузчика и буду потихоньку доделывать оставшуюся работу.
