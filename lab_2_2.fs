//Найти сумму тех элементов списка, в которых встречается заданная цифра.

open System

let rec createList inpList = 
    printf "Введите добавляемое значение(не число - конец): "
    let addVal = System.Int32.TryParse(Console.ReadLine())
    match addVal with
    | (true, intVal) -> 
        createList (inpList @ [intVal])
    | _ ->
        if inpList = [] then
            printfn "В списке должно быть хотя бы одно значение"
            createList inpList
        else inpList

let rec findVal ourInt finVal = 
    let ten = if ourInt >= 0 then 10 else -10
    match ourInt with
    | 0 -> false
    | _ ->
        if finVal = ourInt % ten then 
            true
        else 
            findVal (ourInt / ten) finVal


let sumList finVal acc elem = 
    match findVal elem finVal with
    | true -> acc + elem
    | false -> acc

let rec inpFigure () = 
    printf "Введите цифру, которая должна быть в числе: "
    match System.Int32.TryParse(Console.ReadLine()) with
    | (true, x) when x >= 0 && x < 10 -> x
    | _ ->
        printfn "Ошибка ввода."
        inpFigure ()

[<EntryPoint>]
let main args = 
    let ourList = createList []
    printfn "Созданный список: %A" ourList
    let finVal = inpFigure ()
    let sumListFold = sumList finVal
    let resInt = List.fold sumListFold 0 ourList
    printfn "Сумма чисел содержащие '%i' = %i" finVal resInt
    0