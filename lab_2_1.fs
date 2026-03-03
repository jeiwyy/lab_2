// Получить список из длин строк, содержащихся в исходном списке
open System

let rec createList inpList = 
    printf "Введите добавляемое значение(пустая строка - конец): "
    let addVal = Console.ReadLine()
    match addVal with
    | "" -> inpList
    | _ -> createList (inpList @ [addVal])

[<EntryPoint>]
let main args = 
    printfn "Создание списка"
    let ourList  = createList []
    printfn "Созданный список: %A" ourList
    let resList = List.map String.length ourList 
    printfn "Список длин строк исходного списка: "
    printfn "%A" resList
    0