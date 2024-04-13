Ogólne założenia projektu na studia:

Każdy shelf(półka) w sklepie to osobny wątek, który posiada kolejkę klientów. Każdy klient ma dwie główne cechy (wartość boolean). Albo jest cierpliwy albo nie. Klienci cierpliwi 
zawsze będą czekać do końca pracy magazyniera i dalej zbierać produkty z półek, natomaist klientom niecierpliwym generowany jest poziom cierpliwość (czas jaki mogą poświęcić na 
czekanie w kolejce). Jeżeli ten poziom spadnie poniżej 1 to klienci wychodzą ze sklepu i nie robią dalej zakupów.

Jak działa magazynier?
Jest to zasób wspódzielony. Dzięki mechanizmowi LOCK mamy pewność, że inny wątek nie zmieni wartości magazyniera w momencie kiedyu inny wątek będzie chciał skorzystać z jego wartości.
Magazynier przychodzi do półki sklepowej jeżeli brakuje jakiegoś produktu i uzupełnia jego braki (zawsze dodaje 10 sztuk tego produktu). 

Użytkownik podaje ile jest półek sklepowych (stworzonych wątków)
W każdym wątku automatycznie generowana jest liczba produktów oraz ich ilość. Generowana również jest wielkość kolejki do półki.
