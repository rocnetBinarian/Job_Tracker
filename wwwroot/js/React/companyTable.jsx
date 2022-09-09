class CompanyTable extends React.Component {
    render() {
        const trList = [];
        razorData.forEach((item) => {
            var da = moment(item.DateAdded).format("MM/DD/YY");
            var Applied;
            if (item.DoNotApply == 'True') {
                Applied = (
                    <span class="text-danger font-weight-bold">
                        Did Not Apply
                    </span>
                );
            } else {
                Applied = 
                    <span class="text-success font-weight-bold">
                        Applied
                    </span>
            }
            var MoreInfoURL = "/Company/View/"+item.MoreInfo;
            trList.push(
                <tr>
                    <td>
                        {item.CompanyName}
                    </td>
                    <td>
                        {item.Website}
                    </td>
                    <td>
                        {item.Salary}
                    </td>
                    <td>
                        {Applied}
                    </td>
                    <td>
                        {item.ApplicationStatus}
                    </td>
                    <td>
                        {da}
                    </td>
                    <td>
                        <a href={MoreInfoURL}>More...</a>
                    </td>
                </tr>
            )
        })
        return (
            <table id="companyTable" class="table table-sm table-striped table-hover border-bottom">
                <thead>
                    <tr>
                        <th>
                            Company Name
                        </th>
                        <th>
                            Website
                        </th>
                        <th>
                            Salary Offered (Yearly)
                        </th>
                        <th>
                            Applied?
                        </th>
                        <th>
                            Application Status
                        </th>
                        <th>
                            Date Added
                        </th>
                        <th>
                            More Info
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {trList}
                </tbody>
            </table>
        );
    }
}



const reactRoot = ReactDOM.createRoot(document.getElementById("CompanyList"));
const companyTable = (<CompanyTable />);
reactRoot.render(companyTable);