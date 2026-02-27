//Найти сумму тех элементов списка, в которых встречается заданная цифра.
open System

let rec createList inpList = 
    printf "Введите добавляемое значение(не натур. число - конец): "
    let addVal = System.Int32.TryParse(Console.ReadLine())
    match addVal with
    | (true, intVal) when intVal > 0 -> 
        createList (inpList @ [intVal])
    | _ -> inpList

let rec findVal ourInt finVal = 
    match ourInt with
    | 0 -> false
    | _ ->
        if finVal = ourInt%10 then true
        else findVal (ourInt / 10) finVal

let sumList finVal acc elem = 
    match findVal elem finVal with
    | true -> acc + elem
    | false -> acc

let rec inpFigure () = 
    printf "Введите цифру, которая должна быть в числе: "
    match System.Int32.TryParse(Console.ReadLine()) with
    | (true, x) when x > 0 && x < 10 -> x
    | _ ->
        printfn "Ошибка ввода."
        inpFigure ()

[<EntryPoint>]
let main args = 
    let ourList = createList []
    printfn "%A" ourList
    let finVal = inpFigure ()
    let sumListFold = sumList finVal
    let resList = List.fold sumListFold 0 ourList
    printfn "%A" resList
    0