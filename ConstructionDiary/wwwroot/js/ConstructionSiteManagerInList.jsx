class ConstructionSiteManagerInList extends React.PureComponent {
    constructor(props) {
        super(props);
        this.onClick = this.onClick.bind(this);
    }
    onClick() {
        this.props.onClick(this.props.data.id);
    }
    render() {
        const {
            data: {
                user
            },
            selected
        } = this.props;
        if (!user || (!user.firstName && !user.lastName)) {
            return null;
        }
        return (
            <tr onClick={this.onClick} className={selected ? "selected" : ""}>
                <td>{user ? user.firstName : ""}</td>
                <td>{user ? user.lastName : ""}</td>
            </tr>
        );
    }
}