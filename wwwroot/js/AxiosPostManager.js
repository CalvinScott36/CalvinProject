function AxiosPost(url, data, successUrl, falureUrl) {
    axios({
        method: 'post',
        url: url,
        data: data
    })
        .then(function (response) {
            if (successUrl && typeof successUrl == 'function') {
                debugger;
                successUrl(response.data);
            }
        })
        .catch(function (error) {
            if (falureUrl && typeof falureUrl == 'function') {
                debugger;
                falureUrl(error)
            }
        });

};

function AxiosGet(url, data, successUrl, falureUrl) {
    axios({
        method: 'get',
        url: url,
        data: data
    })
        .then(function (response) {
            if (successUrl && typeof successUrl == 'function') {
                debugger;
                successUrl(response.data);
            }
        })
        .catch(function (error) {
            if (falureUrl && typeof falureUrl == 'function') {
                debugger;
                falureUrl(error)
            }
        });

};