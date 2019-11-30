var countOfFields = 0;
var index = 0;
var divs = new Map();

function clickplus() {
    if (countOfFields < 3) {
        countOfFields++;
        index++;
        var div = document.createElement("div");
        divs[index] = div;
        div.className = "container" + index;
        div.innerHTML = "\
                            <div class=\"inlineBlocks\"> \
                                <label for=\"moreThen\">Если заказ более</label> \
                                <input style=\"max-width: 50px;\" type=\"number\" min=0 name=\"quant\" class=\"quant  discounts\">	\
                            </div>\
                            <div class=\"inlineBlocks\"> \
                                <label for=\"discount\">то скидка</label> 	\
                                <input style=\"max-width: 50px;\" type=\"number\" min=0 step=\"any\" name=\"discount\" class=\"discount  discounts\">	\
                            </div> \
                            <div class=\"inlineBlocks\"> \
                                <label class=\"plusminus\" onclick=\"clickplus()\">+</label>	\
                                <label class=\"plusminus\" onclick=\"clickminus("+ index + ")\">-</label> \
                                <label style=\"margin-left: 15px;\">Можно добавить максимум три скидки</label> \
                            </div>";
        document.getElementById("spetialPrices").appendChild(div);
        return false;
    }
}
function clickminus(index)
{
    if (countOfFields > 1)
    {
        divs[index].parentNode.removeChild(divs[index]);
        delete divs[index];
        countOfFields--;
    }
}

function sendPost()
{
    var arr = new Array();
    $('.discounts').each(function (index, element) {
        arr.push($(element).val());
    });
    var discount = new Map();
    for (var i = 0; i < arr.length; i+=2)
    {
        discount[arr[i]] = arr[i + 1];
    }

    var pr = new Product(document.getElementById("availability").value, document.getElementById("price").value, discount, document.getElementById("self").checked, (document.getElementById("byCity")).checked, document.getElementById("regions").checked);
 
    var body = JSON.stringify(pr);
    
    var xhr = new XMLHttpRequest();
    xhr.open("POST", 'Addproduct');		// 'Addproduct' - файл - обработчик запроса
    xhr.setRequestHeader('Content-Type', 'application/json');           // application/x-www-form-urlencoded            application/json
    xhr.send(body);
}

class Product
{
    constructor(availability, price, discount, self, byCity, regions)
    {
        this.availability = availability;
        this.price = price;
        this.discount = discount;
        this.self = self;
        this.byCity = byCity;
        this.regions = regions;
    }

}
