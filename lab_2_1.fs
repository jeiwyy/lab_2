// Получить список из длин строк, содержащихся в исходном списке
// пустая строка тоже строка - сделать возможность её ввода
open System

let rec createList inpList = 
    printf "Введите добавляемое значение(ctrl+d(z) - конец): "
    let addVal = Console.ReadLine()
    match addVal with
    | null -> inpList
    | _ -> createList (inpList @ [addVal])

[<EntryPoint>]
let main args = 
    printfn "Создание списка"
    let ourList  = createList []
    printfn "\nСозданный список: %A" ourList
    let resList = List.map String.length ourList 
    printfn "Список длин строк исходного списка: "
    printfn "%A" resList
    0