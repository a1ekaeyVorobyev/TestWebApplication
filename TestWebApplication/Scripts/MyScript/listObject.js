


var helloWorldApp = angular.module("myApp", []).controller("myCtrl", function ($scope, $http) {
    $scope.message = "Привет";

    $scope.departmentList = [
        { value: 1, name: "Компютерные инженеры" },
        { value: 2, name: "Электротехники" },
        { value: 3, name: "Бизнес администратор" },
        { value: 4, name: "Пиротехники" }
    ];


    //$scope.GetStudentList = function () {
    //    $http({
    //        traditional: true,
    //        url: "/My/GetStudentList",
    //        method: 'GET',
    //        contentType: "application/json",
    //        dataType: "json"
    //    }).success(function (data) {
    //        $scope.students = data;
    //            alert("Данные полученны данные студента!");

    //    }).error(function (data) {
    //        alert("Не могу получить данные студента!");
    //    });
    //};

    $scope.GetStudentList = function () {
        $http({
            traditional: true,
            url: "/My/GetStudentList",
            method: 'GET',
            contentType: "application/json",
            dataType: "json"
        }).then(function successCallback(response) {
            var data = response.data;
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    if (data[i].ENROLMENT_DATE != null) {
                        var tempDate = new Date(parseInt(data[i].ENROLMENT_DATE.substr(6)));
                        data[i].ENROLMENT_DATE = $scope.FormatFullDate(tempDate);
                    }
                }
                $scope.studentList = data;
                alert("Данные полученны данные студента!");
            }
        }, function errorCallback(response) {
            alert("Не могу получить данные студента!");
        });
    };

    $scope.GetStudentList()

    $scope.depatmetn_name = function (ID) {
        switch (ID) {
            case 1: return "Компютерные инженеры";
            case 2: return "Электротехники";
            case 3: return "Администратор";
            case 4: return "Пиротехники";
            default: return "Не известно";
        }

    }

    $scope.FormatFullDate = function (item) {
        var year = item.getFullYear();
        var month = ('0' + (item.getMonth() + 1)).slice(-2);
        var day = ('0' + (item.getDate())).slice(-2);
        var fullDate = year + "/" + month + "/" + day;
        return fullDate;
    };

    $scope.Delete = function (item) {
        var msg = confirm("Хотите удалить данные студента?");
        if (msg == true) {
            $http({
                traditional: true,
                url: "/My/DeleteStudent",
                method: 'POST',
                data: JSON.stringify({ student: item }),
                contentType: "application/json",
                dataType: "json"
            }).then(function successCallback(response) {
                var data = response.data;
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].ENROLMENT_DATE != null) {
                            var tempDate = new Date(parseInt(data[i].ENROLMENT_DATE.substr(6)));
                            data[i].ENROLMENT_DATE = $scope.FormatFullDate(tempDate);
                        }
                    }
                    $scope.studentList = data;
                }
                alert("Данные удаленны успешно.");
            }, function errorCallback(response) {
                alert("Не могу удалить данные!");
            });
        }
    };

    $scope.Edit = function (item) {
        $scope.std = angular.copy(item);
    };

    $scope.Cancel = function () {
        $scope.std = {};
    };



    $scope.Update = function (std) {
        $http({
            traditional: true,
            url: "/My/UpdateStudent",
            method: 'POST',
            data: JSON.stringify({ student: std }),
            contentType: "application/json",
            dataType: "json"
        }).then(function successCallback(response) {
            var data = response.data;
            $scope.std = {};
            console.log("Загруженны")
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    if (data[i].ENROLMENT_DATE != null) {
                        var tempDate = new Date(parseInt(data[i].ENROLMENT_DATE.substr(6)));
                        data[i].ENROLMENT_DATE = $scope.FormatFullDate(tempDate);
                    }
                }
                $scope.studentList = data;
                console.log($scope.studentList)
            }
            alert("Данные обновленны успешно.");
        }, function errorCallback(response) {
            alert("Не могу обновить данные!");
        });
    };


    $scope.Save = function (std) {
        $http({
            traditional: true,
            url: "/My/SaveStudent",
            method: 'POST',
            data: JSON.stringify({ student: std }),
            contentType: "application/json",
            dataType: "json"
        }).then(function successCallback(response) {
            var data = response.data;
            $scope.std = {};
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    if (data[i].ENROLMENT_DATE != null) {
                        var tempDate = new Date(parseInt(data[i].ENROLMENT_DATE.substr(6)));
                        data[i].ENROLMENT_DATE = $scope.FormatFullDate(tempDate);
                    }
                }
                $scope.studentList = data;
            }
            alert("Даные сохраненны успешно.");
        }, function errorCallback(response) {
            alert("Не могу сохранить данные!");
        });
    };

    $scope.studentList1 = [];

    $scope.AddStudent = function (std) {
        if (std != null) {
            $scope.studentList1.push(std);
            $scope.std = {};
        } else {
            alert('Please insert student info first.');
        }
    };

    $scope.DeleteStudent = function (item) {
        var index = -1;
        var comArr = eval($scope.studentList1);
        for (var i = 0; i < comArr.length; i++) {
            if (comArr[i] === item) {
                index = i;
                break;
            }
        }
        if (index === -1) {
            alert("Something gone wrong");
        }
        $scope.studentList1.splice(index, 1);
    };

    $scope.SaveAsXml = function (studentList1) {
        $http({
            traditional: true,
            url: "/MY/SaveStudentAsXml",
            method: 'POST',
            data: JSON.stringify({ students: studentList1 }),
            contentType: "application/json",
            dataType: "json"
        }).then(function successCallback(response) {
            var data = response.data;
            $scope.std = {};
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    if (data[i].ENROLMENT_DATE != null) {
                        var tempDate = new Date(parseInt(data[i].ENROLMENT_DATE.substr(6)));
                        data[i].ENROLMENT_DATE = $scope.FormatFullDate(tempDate);
                    }
                }
                $scope.studentList = data;
                $scope.studentList1 = [];
                alert("Data saved successfully.");
            }
        }, function errorCallback(response) {
            alert("Could not save student data!");
        });
    };

    $scope.SaveAsTable = function (studentList1) {
        $http({
            traditional: true,
            url: "/My/SaveStudentAsTable",
            method: 'POST',
            data: JSON.stringify({ students: studentList1 }),
            contentType: "application/json",
            dataType: "json"
        }).then(function successCallback(response) {
            var data = response.data;
            $scope.std = {};
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    if (data[i].ENROLMENT_DATE != null) {
                        var tempDate = new Date(parseInt(data[i].ENROLMENT_DATE.substr(6)));
                        data[i].ENROLMENT_DATE = $scope.FormatFullDate(tempDate);
                    }
                }
                $scope.studentList = data;
                $scope.studentList1 = [];
                alert("Data saved successfully.");
            }
        }, function errorCallback(response) {
            alert("Could not save student data!");
        });
    };

});