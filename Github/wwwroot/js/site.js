// Write your JavaScript code.
var ajaxresult = [];
var gitdList = [];
var table = $('<table>').addClass('table ');
$('button').on('click', function () {
    $.ajax({
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
        type: 'GET',
        url: 'https://api.github.com/search/repositories?q=repos+topic:' + $(this).attr('id') + '&sort=stars&order=desc&per_page=10',
        success: function (data) {
           
            ajaxresult.push(data);
            debugger;
            
            table.empty();
            table.append("<thead><tr><th>Avatar</th><th>Name</th><th>Score</th><th>URL</th><th>Updated at</th></tr></thead>");
            $.each(data.items, function (i, object) {
               
                var row = $('<tr>').addClass('table-primary');
                row.append('<td><img src=' + object.owner.avatar_url + 'height=50px width=50px/></td>');
                row.append('<td>' + object.name + '</td>' + '<td>' + object.score + '</td>' + '<td>' + object.url + '</td>' + '<td>' + object.updated_at + '</td>');
                table.append(row);
                
                ajaxresult[i] = { "AvatarURL": object.owner.avatar_url, "Name": object.name, "Score": object.score,"Updatedat": object.updated_at };
            });
            var myJSON = JSON.stringify(ajaxresult);
            var obj = { gitdList: myJSON };
            table.append('</table>');
            $('table').replaceWith(table);
            debugger;
            console.log(obj);
             $.ajax({
                        type: 'POST',
                        url: 'http://localhost:60294/Git/Updateto',    
                        contentType: 'application/json; charset=utf-8',
                 datatype: 'JSON',
                 data: obj,
                       success: function (data) {
                            alert('Post Succesful');
                        },
                        error: function (data) {
                            alert('error');
                        }
                     });
        }

    });

});


