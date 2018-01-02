class ConstructionSitesManagersList extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            constructionSite: window.constructionSite,
            allManagers: [],
            filter: null,
            selected: null
        };

        this.loadManagers = this.loadManagers.bind(this);
        this.renderManagers = this.renderManagers.bind(this);
        this.getManagersToDisplay = this.getManagersToDisplay.bind(this);
        this.filterChange = this.filterChange.bind(this);
        this.managerSelected = this.managerSelected.bind(this);
        this.addSubmitListener = this.addSubmitListener.bind(this);
    }
    componentDidMount() {
        this.loadManagers();
        this.addSubmitListener();
    }
    loadManagers() {
        fetch('/ConstructionSitesManagers')
            .then(res => res.json())
            .then((data) => {
                this.setState(() => ({
                    allManagers: data.data.filter(m => !this.state.constructionSite.ConstructionSiteManagers.find(csm => csm.ConstructionSiteManager.Id === m.id))
                }));
            })
            .catch(err => {
                console.error(err);
            });
    }
    getManagersToDisplay() {
        if (!this.state.filter) {
            return this.state.allManagers;
        }
        const regex = new RegExp(`${this.state.filter}`);
        return this.state.allManagers.filter(m => {
            if (m.user === null) {
                return false;
            }
            const firstNameMatch = m.user.firstName ? m.user.firstName.match(regex) : false;
            const lastNameMatch = m.user.lastName ? m.user.lastName.match(regex) : false;
            const fullNameMatch = m.user.fullName ? m.user.fullName.match(regex) : false;
            return firstNameMatch || lastNameMatch || fullNameMatch;
        });
    }
    managerSelected(id) {
        this.setState(() => ({ selected: id }));
    }
    renderManagers() {
        return this.getManagersToDisplay().map(m => {
            return (
                <ConstructionSiteManagerInList
                    key={m.id}
                    data={m}
                    selected={this.state.selected === m.id}
                    onClick={this.managerSelected} />
            );
        });
    }
    filterChange(e) {
        const text = e.currentTarget.value;
        this.setState(() => ({
            filter: text,
            selected: null
        }));
    }
    submit() {
        const manager = this.state.allManagers.find(m => m.id === this.state.selected);
        const urlParts = window.location.href.split('/');
        const constructionSiteId = parseInt(urlParts[urlParts.length - 1], 10);
        fetch(`/ConstructionSites/SiteManagers/${constructionSiteId}`,
            {
                    credentials: 'include',
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(manager)
                })
            .then(() => {
                location.reload();
            })
            .catch(err => {
                console.error(err);
            });
    }
    addSubmitListener() {
        $('#add-site-manager-submit-button').click(() => {
            this.submit();
        });
    }
    render() {
        return (
            <div className="construction-sites-managers-list">
                <input
                    type="text"
                    placeholder="Filtriraj listu"
                    className="form-control"
                    onChange={this.filterChange}
                    value={this.state.filter || ""} />
                <table className="table table-hover">
                    <thead>
                        <tr>
                            <th>First name</th>
                            <th>Last name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderManagers()}
                    </tbody>
                </table>
            </div>
        );
    }
}

ReactDOM.render(
    <ConstructionSitesManagersList />,
    document.getElementById('managers-list-root')
);