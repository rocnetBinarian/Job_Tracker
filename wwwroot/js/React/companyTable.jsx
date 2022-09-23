class CompanyTable extends React.Component {
    constructor(props) {
        super(props);
        this.DefaultListData = [];
        this.AppStatusEnumTags = [];
        this.state = {
            sortState: 0,
            sortIcon: "fa-solid fa-sort",
            listData: this.DefaultListData
        };

        this.changeSort = this.changeSort.bind(this);
        this.componentDidMount = this.componentDidMount.bind(this);
    };

    componentDidMount() {
        var ctThis = this;
        $.ajax({
            url: "/CompanyList/",
            method: 'GET',
            success: function(r) {
                ctThis.DefaultListData = r.companyList;
                ctThis.AppStatusEnumTags = r.enumNames;
                ctThis.setState({
                    listData: ctThis.DefaultListData
                });
            }
        });
    }

    changeSort() {
        if (this.state.sortState == 0) {
            this.setState((prev, cur) => ({
                sortState: 1,
                sortIcon: "fa-solid fa-sort-up",
                listData: [...this.DefaultListData].sort(
                    (a, b) => (
                            b.DateAdded - a.DateAdded
                        )
                    )
            }));
        } else if (this.state.sortState == 1) {
            this.setState((prev, cur) => ({
                sortState: -1,
                sortIcon: "fa-solid fa-sort-down",
                listData: [...this.DefaultListData].sort(
                    (a, b) => (
                            a.DateAdded - b.DateAdded
                        )
                    )
            }));
        } else if (this.state.sortState == -1) {
            this.setState((prev, cur) => ({
                sortState: 0,
                sortIcon: "fa-solid fa-sort",
                listData: this.DefaultListData
            }));
        }
    };

    render() {
        const trList = [];

        this.state.listData.forEach((item) => {
            var da = moment(item.dateAdded).format("MM/DD/YY");
            var Applied;
            if (item.doNotApply) {
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

            var MoreInfoURL = "/Company/View/"+item.id;
            trList.push(
                <tr key={item.id}>
                    <td>
                        {item.companyName}
                    </td>
                    <td>
                        {item.website}
                    </td>
                    <td>
                        {item.salaryOffered}
                    </td>
                    <td>
                        {Applied}
                    </td>
                    <td>
                        {this.AppStatusEnumTags[item.applicationStatus]}
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
                            Date Added <a href="#" onClick={this.changeSort}><i class={this.state.sortIcon}></i></a>
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